namespace BytesPack.Sterling.Shared.Interfaces
{
    public interface ISendResetPasswordEmailRequest
    {
        string Email { get; set; }
        string Url { get; set; }
        string UserName { get; set; }
    }
}
