using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsRepository
{
    public class CmsPageRepository
    {
        public CmsPageRepository()
        {

        }

        public void GetPages()
        {
            var reader = new SqlExecuteQueryDataReader();

            var resul = reader.ExecuteQuery("select Title, Text from CMSPage", c => new CmsPageDTO { Title = c.GetString(0), Text = c.GetString(1) });
        }
    }
}
