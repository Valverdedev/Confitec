using Application.Dtos.UsuarioDtos;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using Domain;
using Domain.Entidades;
using Domain.ServiceInterfaces;
using System.Reflection.Metadata.Ecma335;

namespace Application.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService( IMapper mapper, IUsuarioService usuarioService) 
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<ObjetoDeRetorno<UsuarioDto>> AtualizarAsync(int id, InserirUsuarioDto inserirUsuarioDto)
        {
            try
            {
                  var usuario = await ObterPorIdAsync(id);

                if (usuario.Sucesso)
                {   
                        inserirUsuarioDto.Id = id;
                        var usuarioAtualizado = _mapper.Map<Usuario>(inserirUsuarioDto);
                        
                        await _usuarioService.AtualizarAsync(usuarioAtualizado);
    
                        var usuarioDto = _mapper.Map<UsuarioDto>(usuarioAtualizado);
    
                        return ObjetoDeRetorno<UsuarioDto>.Ok(usuarioDto, "Usuário atualizado com sucesso");
                }
                    return ObjetoDeRetorno<UsuarioDto>.Falha("Usuário não encontrado");
            }
            catch (RegrasDeNegocioException ex)
            {

                return ObjetoDeRetorno<UsuarioDto>.Falha(ex.Message);
            }
        }

        public async Task<ObjetoDeRetorno<UsuarioDto>> ExcluirAsync (int id)
        {
            try
            {
              await _usuarioService.ExcluirAsync(id);

                return ObjetoDeRetorno<UsuarioDto>.Ok(null, "Usuário excluído com sucesso");
            }
            catch (RegrasDeNegocioException ex)
            {

                return ObjetoDeRetorno<UsuarioDto>.Falha(ex.Message);
            }
          
        }

        public async Task<ObjetoDeRetorno<UsuarioDto>> InserirAsync(InserirUsuarioDto dto)
        {
            try
            {
                var usuario = _mapper.Map<Usuario>(dto);

                usuario = await _usuarioService.InserirAsync(usuario);

                var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

                return ObjetoDeRetorno<UsuarioDto>.Ok(usuarioDto);
            }
            catch (RegrasDeNegocioException ex )
            {
                return ObjetoDeRetorno<UsuarioDto>.Falha(ex.Message);
                
            }
            catch (Exception ex)
            {                
                return ObjetoDeRetorno<UsuarioDto>.Falha(ex.Message);
            }

        }

        public async Task<ObjetoDeRetorno<IList<UsuarioDto>>> ListarTodosAsync()
        {
            try
            {
                var usuarios = await _usuarioService.ListarTodosAsync();
                var usuariosDto = _mapper.Map<IList<UsuarioDto>>(usuarios);

                return ObjetoDeRetorno<IList<UsuarioDto>>.Ok(usuariosDto);               
                
            }
            catch (RegrasDeNegocioException ex)
            {

               return ObjetoDeRetorno<IList<UsuarioDto>>.Falha(ex.Message);
            }
        }

        public async Task<ObjetoDeRetorno<UsuarioDto>> ObterPorIdAsync(int id)
        {
            try
            {
                var usuario = await _usuarioService.ObterPorIdAsync(id);
                var usuariosDto = _mapper.Map<UsuarioDto>(usuario);

                return ObjetoDeRetorno<UsuarioDto>.Ok(usuariosDto);
            }
            catch (RegrasDeNegocioException ex)
            {

                return ObjetoDeRetorno<UsuarioDto>.Falha(ex.Message);
            }
        }
    }
}
