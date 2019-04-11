using _14NET.ProjetoMasterChef.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _14NET.ProjetoMasterChef.UI.Helpers
{
    public class Helper
    {
        public ReceitaViewModel SalvarImagem(ReceitaViewModel receitaViewModel, string webRootPath)
        {
            string fileName = receitaViewModel.Foto.FileName.Split(".")[0] + "_" + DateTime.Now.Millisecond;

            if (receitaViewModel.Foto.FileName.Contains(".jpg"))
                fileName += ".jpg";
            else if (receitaViewModel.Foto.FileName.Contains(".png"))
                fileName += ".png";

            //Salva somente o caminho do arquivo no banco, pois será retornado de forma interna pela app
            receitaViewModel.FotoURL = fileName;

            //cria o arquivo para o local de destino "wwwroot/Site_Images" + nome do arquivo
            using (var stream = new FileStream(webRootPath + "\\Site_Images\\" + fileName, FileMode.Create))
            {
                receitaViewModel.Foto.OpenReadStream().CopyTo(stream);
            }            

            return receitaViewModel;
        }
    }
}
