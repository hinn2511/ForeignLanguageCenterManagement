﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTamNgoaiNgu.DAL;

namespace TrungTamNgoaiNgu.BUS
{
    public class Bus_ThiSinh
    {
        Dal_ThiSinh dal = new Dal_ThiSinh();

        public List<ThiSinh> LayDanhSachTS()
        {
            return dal.LayDanhSachThiSinh();
        }
    }
}
