using wci.App.Models;

namespace wci.App.Services;

public interface ILuCIService
{
    Login Login(string ip, string username, string password);
    void Logout();
    SidenavItem[] GetMenu();
    Overview GetOverview();
}

internal sealed class LuCIService : ILuCIService
{
    public Login Login(string ip, string username, string password)
    {
        // mock error login with 'error' password, else success with mock token response
        return password == "error"
            ? new Login { Error = "Invalid credentials! Please try again." }
            : new Login { Token = "65e60c5a93b2f2c05e61681bf5e94b49" };
    }

    public void Logout()
    {
        // call luci rpc logout
    }

    public SidenavItem[] GetMenu()
    {
        //\xEA0D dsahobaord \xEB91 \xEBD2 \xEC27 \xEC26 \xE946 \xEC4E \xECA5 \xECAA
        // \xEA35 software floppy
        return [
            new() {
                PageName = "OverviewPage",
                Title = "Dashboard",
                Icon = "\xF246" /*"\xECAA"*/
            },
            new() {
                Title = "Status",
                Icon = "\xE95E",
                Items = [
                    new() {
                        PageName = "RoutingPage",
                        Title = "Routing",
                        Icon = "\xF003"
                    },
                    new() {
                        PageName = "FirewallPage",
                        Title = "Firewall",
                        Icon = "\xE730"
                    },
                    new() {
                        PageName = "SystemLogPage",
                        Title = "System Log",
                        Icon = "\xE71D"
                    },
                    new() {
                        PageName = "ProcessesPage",
                        Title = "Processes",
                        Icon = "\xE9F5"
                    },
                    new() {
                        PageName = "ChannelAnalysisPage",
                        Title = "Channel Analysis",
                        Icon = "\xEB44"
                    },
                    new() {
                        PageName = "RealtimeGraphsPage",
                        Title = "Realtime Graphs",
                        Icon = "\xE9D2"
                    }
                ]
            },
            new() {
                Title = "System",
                Icon = "\xE770",
                Items = [
                    new() {
                        PageName = "SystemPage",
                        Title = "System",
                        Icon = "\xE975"
                    },
                    new() {
                        PageName = "AdministrationPage",
                        Title = "Administration",
                        Icon = "\xE7EF"
                    },
                    new() {
                        PageName = "SoftwarePage",
                        Title = "Software",
                        Icon = "\xE958"
                    },
                    new() {
                        PageName = "StartupPage",
                        Title = "Startup",
                        Icon = "\xE756"
                    },
                    new() {
                        PageName = "ScheduledTasksPage",
                        Title = "Scheduled Tasks",
                        Icon = "\xEE93"
                    },
                    new() {
                        PageName = "AttendedSysupgradePage",
                        Title = "Attended Sysupgrade",
                        Icon = "\xE895" /*\xEDAB*/
                    },
                    new() {
                        PageName = "LEDConfigurationPage",
                        Title = "LED Configuration",
                        Icon = "\xE781"
                    },
                    new() {
                        PageName = "BackupFlashFirmwarePage",
                        Title = "Backup Flash Firmware",
                        Icon = "\xE950"
                    },
                    new() {
                        PageName = "RebootPage",
                        Title = "Reboot",
                        Icon = "\xE7E8"
                    }
                ]
            },
            new() {
                Title = "Services",
                Icon = "\xE713",
                Items = [
                    new() {
                        PageName = "BanIPPage",
                        Title = "BanIP",
                        Icon = "\xF140"
                    }
                ]
            },
            new() {
                Title = "Network",
                Icon = "\xEDA3",
                Items = [
                    new() {
                        PageName = "InterfacesPage",
                        Title = "Interfaces",
                        Icon = "\xE839" /*\xEE77*/
                    },
                    new() {
                        PageName = "WirelessPage",
                        Title = "Wireless",
                        Icon = "\xEC3F"
                    },
                    new() {
                        PageName = "RoutingPage",
                        Title = "Routing",
                        Icon = "\xF0B9"
                    },
                    new() {
                        PageName = "DHCPandDNSPage",
                        Title = "DHCP and DNS",
                        Icon = "\xE774"
                    },
                    new() {
                        PageName = "DiagnosticsPage",
                        Title = "Diagnostics",
                        Icon = "\xE9D9"
                    },
                    new() {
                        PageName = "SQMQoSPage",
                        Title = "SQM QoS",
                        Icon = "\xEC4A"
                    },
                    new() {
                        PageName = "FirewallPage",
                        Title = "Firewall",
                        Icon = "\xEA18"

                    }
                ]
            }
        ];
    }

    public Overview GetOverview()
    {
        return new()
        {
            Hostname = "OpenWrt",
            Model = "GL.iNet GL-MT6000",
            Architecture = "ARMv8 Processor rev 4",
            Platform = "mediatek/filogic",
            FirmwareVersion = "OpenWrt 24.10.4 r28959-29397011cc / LuCI openwrt-24.10 branch 25.292.66247~75e41cb",
            KernelVersion = "6.6.110",
            Uptime = "26d 13h 31m 22s"
        };
    }
}