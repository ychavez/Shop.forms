using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Backend
{
    public partial class frmNotification : Form
    {
        public frmNotification()
        {
            InitializeComponent();
        }

        private void btnEnviarNotificatificacion_Click(object sender, EventArgs e)
        {
            PushNotificationHandle pushNotificationHandle = new PushNotificationHandle();
            pushNotificationHandle.SendNotification(txtTitulo.Text, txtMensaje.Text, "Todes");
        }
    }
}
