﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services {
    public class DepartmentsService {

        private readonly WebApplication2Context _context;

        public DepartmentsService(WebApplication2Context context) {
            _context = context;
        }

        public List<Departments> FindAll() => _context.Departments.OrderBy(x => x.Nome).ToList();
    }
}
