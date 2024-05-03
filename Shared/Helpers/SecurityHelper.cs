﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class SecurityHelper
    {
        public static string GenerateHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool ValidateHash(string password, string actualPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, actualPassword);
        }
    }
}
