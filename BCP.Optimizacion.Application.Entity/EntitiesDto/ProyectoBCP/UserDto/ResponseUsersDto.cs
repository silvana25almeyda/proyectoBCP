﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Optimizacion.Application.Entity
{
    public class ResponseUsersDto
    {
        public MetadataDto metadata { get; set; }
        public List<UserDto> usuarios { get; set; }
    }
}
