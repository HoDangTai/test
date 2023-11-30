using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyNhanSu_HoDangTai_63135354.Startup))]
namespace QuanLyNhanSu_HoDangTai_63135354
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
