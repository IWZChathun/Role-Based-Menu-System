using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RBMS.Entities;
using RBMS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RBMS.Helpers
{
    public class AuthHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly SessionManager _sessionManager;
        private List<Claim> _claims;

        public User User { get; private set; }
        public string Token { get; private set; }

        public AuthHelper(ApplicationDbContext context, SessionManager  sessionManager)
        {
            _context = context;
            _sessionManager = sessionManager;
        }

        public async Task<bool> Authenticate(Credentials credentials)
        {
            User = await _context.Users
                .Include((u)=> u.UserRole)
                .ThenInclude((r) => r.UserAccesses)
                .FirstOrDefaultAsync(x => x.Username == credentials.Username);
            if (User is null)
                return false;

            SetClaims();
            GetToken();

            return true;
        }

        private void GetToken()
        {
            var securityKey = new SymmetricSecurityKey(_sessionManager.Salt);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_sessionManager.Issuer, _sessionManager.Audiance, _claims, null, DateTime.Now.AddDays(30), signingCredentials);
            this.Token = new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void SetClaims()
        {
            var accesses = "";

            foreach (var access in User.UserRole.UserAccesses)
            {
                accesses += $"{access.Module};";
            }

            this._claims = new()
            {
                new Claim(ClaimTypes.Sid, User.Id.ToString()),
                new Claim(ClaimTypes.Name, User.FirstName + " " + User.LastName),
                new Claim(ClaimTypes.WindowsAccountName, User.Username),
                new Claim(ClaimTypes.Role, User.UserRole.Role),
                new Claim("access", accesses),
            };
        }
    }
}
