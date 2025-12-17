
using BatchRecord.Domain.DTOs.Autenticacion;
using BatchRecord.Domain.Enums;
using BatchRecord.Domain.Helpers;
using BatchRecord.Domain.Ports;
using BatchRecord.Domain.QueryFilters;

namespace BatchRecord.Domain.Services.Autenticacion
{
    [DomainService]
    public class AutenticacionService(
        IQueryWrapper queryWrapper
    )
    {
        public async Task<AuthResponseDto> GetUser(string user, string password)
        {
            List<FieldFilter> listFilters = [];

            AuthResponseDto? authResponse = null;

            try
            {
                var userRes = await queryWrapper
                    .QueryAsync<EmpUsuariosDto>
                        (ItemsMessageConstants.GetEmpUsuarios
                            .GetDescription(),
                            new
                            { idUsuario = user },
                            FieldFilterHelper.BuildQueryArgs(listFilters)
                        );

                Usuario? usuario = null;

                foreach (var row in userRes)
                {
                    if (usuario == null)
                    {
                        usuario = new Usuario
                        {
                            Id = row.IdUsuari,
                            Password = row.UsuPassword,
                            IdEmpresa = row.IdEmpresa,
                            EmpresasLogicas = new List<EmpresaPermisosDto>()
                        };
                    }

                    usuario.EmpresasLogicas.Add(new EmpresaPermisosDto
                    {
                        Defecto = row.Defecto,
                        IdEmpresaLogica = row.IdEmpresaLogica,
                        NomEmpresaLogica = row.NomEmpresaLogica
                    });
                }

                if (usuario == null)
                    return null;

                var decrypt = await queryWrapper
                    .QuerySingleAsync<Contrasena>
                        (ItemsMessageConstants.DesencriptarPassword
                           .GetDescription(),
                           new
                           {
                               IdUsuario = usuario.Id,
                               usuario.Password
                           },
                           FieldFilterHelper.BuildQueryArgs(listFilters)
                        );


                if (decrypt.contrasena == password)
                {
                    List<EmpresaPermisosDto> empresasLogicas = [];
                    foreach (var empresas in usuario.EmpresasLogicas)
                    {
                        empresasLogicas.Add(empresas);
                    }
                    string token = "token";//Generara token
                    UsuarioDto usuarioDto = new UsuarioDto
                    {
                        Id = usuario.Id,
                        Nombre = usuario.Nombre,
                        IdEmpresa = usuario.IdEmpresa,
                        EmpresasLogicas = empresasLogicas
                    };
                    authResponse = new AuthResponseDto(token, usuarioDto);
                }

                return authResponse;

            }
            catch (Exception e)
            {
                var x = 1;
            }
            return null;
        }

        public async Task<PermisosSalidaDto> ObtenerPermisosAsync(string idObjeto, string idUsuario)
        {
            var permisos = await queryWrapper
                .QueryAsync<PermisosDto>
                    (ItemsMessageConstants.GetPermisos
                       .GetDescription(),
                       new
                       {
                           IdObjeto = idObjeto,
                           IdUsuario = idUsuario
                       },
                       FieldFilterHelper.BuildQueryArgs([])
                    );

            if (permisos == null || !permisos.Any())
                return null;

            string binario = Convert.ToString(permisos.FirstOrDefault().NivelA, 2).PadLeft(6, '0');
            string binarioInvertido = new(binario.Reverse().ToArray());

            PermisosSalidaDto permisosAcceso = new()
            {
                IdObjeto = permisos.FirstOrDefault().IdObjeto,
                IdUsuari = permisos.FirstOrDefault().IdUsuari,
                NivelA = new()
                {
                    Listar = binarioInvertido[0] == '1',
                    Propiedades = binarioInvertido[1] == '1',
                    Crear = binarioInvertido[2] == '1',
                    Modificar = binarioInvertido[3] == '1',
                    Anular = binarioInvertido[4] == '1',
                    Eliminar = binarioInvertido[5] == '1'
                },
                NivelAccesoCtrl = []
            };

            List<NivelAccesoCtrlDto> listNivelAccesoCtrl = [];
            foreach (var permiso in permisos)
            {
                if (permiso.IdCtrl != null)
                {
                    NivelAccesoCtrlDto nivelAccesoCtrl = new()
                    {
                        IdObjeto = permiso.IdObjeto,
                        IdCtrl = permiso.IdCtrl,
                        VisCtrl = permiso.VisCtrl,
                        HabCtrl = permiso.HabCtrl
                    };

                    listNivelAccesoCtrl.Add(nivelAccesoCtrl);
                }
            }

            permisosAcceso.NivelAccesoCtrl = listNivelAccesoCtrl;

            return permisosAcceso;
        }

    }
}
