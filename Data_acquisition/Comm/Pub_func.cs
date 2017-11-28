using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Comm
{
    class Pub_func
    { 
    /// <summary>
    ///  清空gridview控件里的内容
    /// </summary>
        /// <param name="dgv">gridview控件</param>
      public static void grid_clear(DataGridView dgv){
          DataTable dt = (DataTable)dgv.DataSource;
          if(dt==null)return;
          dt.Rows.Clear();
          dgv.DataSource = dt;     
      }
    }
}
