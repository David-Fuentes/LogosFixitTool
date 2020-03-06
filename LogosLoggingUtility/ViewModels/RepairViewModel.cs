using LogosLoggingUtility.Model;
using LogosLoggingUtility.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LogosLoggingUtility.ViewModels
{
    public class RepairViewModel : ViewModel
    {
        public RepairViewModel(SupportViewModel supportInfoViewModel)
        {
            m_supportInfoViewModel = supportInfoViewModel;
        }

        internal bool CanFindRepairFile()
        {
            var result = false;
            if (m_supportInfoViewModel.PreferredSoftware == SupportModel.c_Logos)
            {
                if (File.Exists($@"{m_supportInfoViewModel.FilePath}\Install\Installers\Logos-x64.msi"))
                {
                    result = true;
                    m_RepairPath = $@"{m_supportInfoViewModel.FilePath}\Install\Installers\Logos-x64.msi";
                }
                else if (File.Exists($@"{m_supportInfoViewModel.FilePath}\Install\Installers\Logos4Prerequisites.msi"))
                {
                    result = true;
                    m_RepairPath = $@"{m_supportInfoViewModel.FilePath}\Install\Installers\Logos4Prerequisites.msi";
                }
            }
            else
            {
                if (File.Exists($@"{m_supportInfoViewModel.FilePath}\Install\Installers\Verbum-x64.msi"))
                {
                    result = true;
                    m_RepairPath = $@"{m_supportInfoViewModel.FilePath}\Install\Installers\Verbum-x64.msi";
                }
            }
            return result;
        }

        internal void RepairInstallation()
        {
            try
            {
                Process.Start(m_RepairPath);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Unable to open repair file: {e}");
            }
        }

        private readonly SupportViewModel m_supportInfoViewModel;
        private string m_RepairPath;
    }
}
