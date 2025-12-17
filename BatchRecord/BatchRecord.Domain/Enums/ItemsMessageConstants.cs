using System.ComponentModel;

namespace BatchRecord.Domain.Enums
{
    public enum ItemsMessageConstants
    {
        [Description("GetEmpUsuarios")]
        GetEmpUsuarios,

        [Description("DesencriptarPassword")]
        DesencriptarPassword,

        [Description("GetPermisos")]
        GetPermisos,

        [Description("GetVentas")]
        GetVentas,

        [Description("GetYearsOfVentas")]
        GetYearsOfVentas,

        [Description("GetCostCenterOfVentas")]
        GetCostCenterOfVentas,
    }
}
