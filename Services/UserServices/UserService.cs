using DevPloyClasses.Dto.UserDtos;
using DevPloyClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AgentBuilderApi.Services.UserServices
{
    public enum UserStatus
    {   
        // TODO: Is usefull or useless???
        Registred,
        Logged,
    }
    /// <summary>
    /// TODO: OTP
    /// TODO: Recovery Psw
    /// TODO: Update DB entyties
    /// TODO: Rate Limiting
    /// TODO: Captcha
    /// </summary>
    public class UserService : IUserService
    {
        private IConfiguration _config { get; set; }
        public DataContext _dataContext { get; set; }

        /// <summary>
        /// An istance constructur for user service via DI
        /// </summary>
        /// <param name="context">the db context injected</param>
        /// <param name="config">app configurations settings injected</param>
        public UserService(DataContext context, IConfiguration config)
        {
            this._dataContext = context;
            this._config = config;
        }

        #region Main Methods
        /// <summary>
        /// TODO: implement a personal logging system in order to better notification and flow system
        /// TODO: move OTP in redit
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Jeson Web Token</returns>
        public async Task<ServiceResponse<string>> LogIn(UserDtoLogIn user)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var properties = typeof(UserDtoLogIn).GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(user) as string;
                    if (!string.IsNullOrEmpty(value) && prop.Name != nameof(UserDtoLogIn.Pasword))
                    {
                        var logged_user = await FindUserByPropertyAsync(prop.Name, value);
                        if (logged_user != null)
                        {
                            bool logged = Verify(user.Pasword, logged_user.PasswordHash, logged_user.PasswordSalt);

                            if (logged)
                            {
                                //HINT: Sospendo implementazione OTP
                                //response.Data = CreateToken(logged_user);
                                //var otp = GenerateOtp();

                                //logged_user.Otp = otp;
                                //logged_user.OtpExpiry = DateTime.UtcNow.AddMinutes(5);
                                //await _dataContext.SaveChangesAsync();

                                response.Data =CreateToken(logged_user);
                                response.Succes = true;
                                response.Message = $"User with Id:{logged_user.Id} creedential verified";
                            }
                            else
                            {
                                response.Succes = false;
                                response.Message = "Unmaching Credential";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Succes = false;
                response.Message = "Somentige Gose Wrong";
                Console.WriteLine(ex.Message);
            }

            return response;
        }
        /// <summary>
        /// TODO: Implement a psw/email validation system
        /// TODO: Implement OTP
        /// FIX: What caind of data we should response? >>>> errors handeling
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<string>> Register(UserDtoRegister user)
        {
            var response = new ServiceResponse<string>();

            try
            {
                if (await Exisist(user.Username))
                {
                    response.Succes = false;
                    response.Message = "User Arlady Exisist";
                }

                else
                {
                    CreatePasswordHash(user.Password, out byte[] hash, out byte[] salt);


                    //TODO: Add Automapper
                    UserModel newUswer = new UserModel{
                        BillingAdress = user.BillingAdress,
                        Username = user.Username.ToLower(),
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        PasswordHash = hash,
                        PasswordSalt = salt,
                        Status = UserStatus.Registred.ToString(),
                    };

                    _dataContext.Users.Add(newUswer);
                    await _dataContext.SaveChangesAsync();
                    response.Data = $"{newUswer.Username} Succesfuly registred";
                    response.Message = response.Data;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Succes = false;
            }

            return response;
        }
        public Task<ServiceResponse<bool>> GetOtp(UserModel user, string pasw) => throw new NotImplementedException();
        public Task<ServiceResponse<string>> RefreshToken(UserModel user, string pasw) => throw new NotImplementedException();
        #endregion

        #region TODO: implement update methods
        #endregion

        #region Class_Services
        /// <summary>
        /// Looking for User in DB
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>Possible null returned</returns>
        private async Task<UserModel?> FindUserByPropertyAsync(string propertyName, string value)
        {
            UserModel? user = propertyName switch
            {
                nameof(UserDtoLogIn.Email) => await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == value),
                nameof(UserDtoLogIn.Username) => await _dataContext.Users.SingleOrDefaultAsync(u => u.Username == value),
                nameof(UserDtoLogIn.PhoneNumber) => await _dataContext.Users.SingleOrDefaultAsync(u => u.PhoneNumber.ToString() == value),
                _ => null
            };
            return user;
        }
        /// <summary>
        /// Verifing User existence in context via username
        /// </summary>
        /// <param name="username">username as string</param>
        /// <returns>bool rappresenting user existance</returns>
        private async Task<bool> Exisist(string username)
        {
            bool exist = false;
            try
            {
                if (await _dataContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
                    exist = true;
            }
            catch (Exception)
            {

                exist = false;
            }

            return exist;
        }

        /// <summary>
        /// Hashing Pasword
        /// </summary>
        /// <param name="pasw"></param>
        /// <param name="pswHash"></param>
        /// <param name="paswSalt"></param>
        private void CreatePasswordHash(string pasw, out byte[] pswHash, out byte[] paswSalt)
        {
            using (var cr = new System.Security.Cryptography.HMACSHA512())
            {
                paswSalt = cr.Key;
                pswHash = cr.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pasw));
            }
        }

        private bool Verify(string pass, byte[] passHash, byte[] passSalt)
        {
            // uncrypt the dbpas using the salt
            using (var hmc = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                // hash from psw
                var computedHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));

                // comparing byte for byte with the hash
                return computedHash.SequenceEqual(passHash);
            }
        }

        /// <summary>
        /// TODO: menagine expiration data
        /// </summary>
        /// <param name="user"></param>
        /// <returns>jeson web token</returns>
        /// <exception cref="Exception"></exception>
        private string CreateToken(UserModel user)
        {
            // aggiungo una lista di claims come descrizione utente
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            // recupero parte e della chiave simmetrica archiviata nei settings
            var appSettingsToken = _config.GetSection("AppSettings:Token").Value;

            if (appSettingsToken == null)
                throw new Exception("AppSettings Token is null");

            // Genero la chiave simmetrica
            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

            // Genero le credenziali crittografate
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Genero il Token
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = cred
            };

            // Un gestore per creare e scrivere il token
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(tokenDescription);

            return handler.WriteToken(token);
        }

        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(0001, 9999).ToString();
        }

        #endregion

    }
}
