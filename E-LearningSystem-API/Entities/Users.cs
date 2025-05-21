namespace E_LearningSystem_API.Entities
{
    public class Users:MainEntity
    {

        public string FirstName { get; set; } 
        public string LasttName { get; set; }
        public string Password { get; set; } //hased 
        public string Email { get; set; } //hashed
        public string? OTPCode { get; set; }
        public DateTime? OTPExipry { get; set; }
        public int RoleId { get; set; }
        public bool IsVerfied { get; set; } = false;
        public bool? IsLoggedIn { get; set; } = false;
        public DateTime? LastLoginTime { get; set; }
    }
}
