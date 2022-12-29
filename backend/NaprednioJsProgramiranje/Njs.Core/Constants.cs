﻿namespace Njs.Core;

public static class Constants
{
    public const string InvalidTenantId = nameof(InvalidTenantId);

    public static class Claims
    {
        public const string Sid = nameof(Sid);

        public const string TenantId = nameof(TenantId);
    }

    public static class VerificationLinks
    {
        public const int AccountConfirmationExpirationMinutes = 15;
        
        public static string GetAccountConfirmationLink(string token) => $"/account/confirm/{token}";

        public static string GetPasswordResetLink(string token) => $"/account/reset-password/{token}";
    }

    public static class Jwt
    {
        public const int AccessTokenExpirationDays = 1;

        public const int RefreshTokenExpirationDays = 30;
    }

    public static class Hangfire
    {
        public static class TenantParameters
        {
            public const string TenantId = nameof(TenantId);
        }
    }
}