﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models.Authentication
{
        public class RegistrationModel
        {
            public string Email { get; set; }
            [DataType(DataType.Password)]
            public string Password { get; set; }
            public string Name { get; set; }
        }

}