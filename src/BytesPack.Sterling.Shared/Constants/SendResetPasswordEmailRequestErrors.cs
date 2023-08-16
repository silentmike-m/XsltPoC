namespace BytesPack.Sterling.Shared.Constants
{
    public static class SendResetPasswordEmailRequestErrors
    {
        public static readonly string EMPTY_EMAIL_CODE = "send_reset_password_email_empty_email";
        public static readonly string EMPTY_EMAIL_MESSAGE = "Receiver email can not be empty";
        public static readonly string EMPTY_URL_CODE = "send_reset_password_email_empty_url";
        public static readonly string EMPTY_URL_MESSAGE = "Reset password url can not be empty";
        public static readonly string EMPTY_USER_NAME_CODE = "send_reset_password_email_empty_user_name";
        public static readonly string EMPTY_USER_NAME_MESSAGE = "User name can not be empty";
    }
}