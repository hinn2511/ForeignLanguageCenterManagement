using System;
using System.Collections.Generic;
using System.Linq;

namespace TrungTamNgoaiNgu.DAL
{
    internal class Dal_ThiSinh
    {
        QLTTNNDataContext context = new QLTTNNDataContext();

        public List<ThiSinh> LayDanhSachThiSinh()
        {
            List<ThiSinh> TS = context.ThiSinhs.Select(ts => ts).ToList();
            return TS;
        }

        public bool ThemTs (ThiSinh thiSinh)
        {
            context.ThiSinhs.InsertOnSubmit(thiSinh);
            try
            {
                context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaTs (int TsId)
        {
            var DeleteTS = context.ThiSinhs.FirstOrDefault(ts => ts.Id == TsId);

            if (DeleteTS != null)
            {
                context.ThiSinhs.DeleteOnSubmit(DeleteTS);

                try
                {
                    context.SubmitChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return false;  
        }

        public ThiSinh LayThongTinTS (int id)
        {
            var ts = context.ThiSinhs.FirstOrDefault(t =>t.Id == id);
            return ts;
        }
    }
}
