using API.Configuration;
using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthManagmentController : ControllerBase
	{
		private readonly JwtConfig _jwtConfig;
		private readonly TokenValidationParameters _tokenValidationParameters;

		public AuthManagmentController(IOptionsMonitor<JwtConfig> optionsMonitor, TokenValidationParameters tokenValidationParameters)
		{
			_jwtConfig = optionsMonitor.CurrentValue;
			_tokenValidationParameters = tokenValidationParameters;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] EmployeeRequest user)
		{
			using(var db = new DbRoadRussiaContext())
			{
				var existingUser = db.Employees.Where(u => u.Login == user.Login).FirstOrDefault();
				if (existingUser != null)
				{
					var isCorrect = existingUser.Password == user.Password;
					if (isCorrect)
					{
						return Ok(await GenerateJwtToken(existingUser));
					}
					else
					{
						return BadRequest(new ResultResponse()
						{
							Success = false,
							Errors = new List<string>()
							{
								"Пароль ввведен неверно!"
							}
						});
					}
				}
				return BadRequest(new ResultResponse()
				{
					Success = false,
					Errors = new List<string>()
					{
						$"Пользователь с логином {user.Login} отсутствует в БД!"
					}
				});
			}
		}

		private async Task<ResultResponse> GenerateJwtToken(Employee user)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim("Id", user.Id.ToString()),
					new Claim("Name", user.Name),
					new Claim("Surname", user.Surname),
					new Claim(JwtRegisteredClaimNames.Sub, "test"),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
				}),
				Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTimeFrame),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature)
			};

			//получение токена
			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			//запись токена
			var jwtToken = jwtTokenHandler.WriteToken(token);
			return new ResultResponse()
			{
				Token = jwtToken,
				Success = true,
			};
		}
	}
}
