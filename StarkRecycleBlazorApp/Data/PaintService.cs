using StarkRecycleBlazorApp.Data;
using ClassLibraryProducts;
using System.Text.Json;

namespace StarkRecycleBlazorApp.Data
{
    public class PaintService : IPaintService
    {
        private string paintFile = "Paint.json";
        private IList<Paint> paintList;

        public PaintService()
        {
            if (!File.Exists(paintFile))
            {
                WritePaintFile();
            } else
            {
                string content = File.ReadAllText(paintFile);
                paintList = JsonSerializer.Deserialize<List<Paint>>(content);
            }
        }
        public async Task<IList<Paint>> GetPaintsAsync()
        {
            List<Paint> tmp = new List<Paint>(paintList);
            return tmp;
        }
        public async Task AddPaintAsync(Paint paint)
        {
            int max = paintList.Max(Paint => Paint.PaintId);
            paint.PaintId = (++max);
            paintList.Add(paint);
            WritePaintFile();
        }

        public async Task EditPaintAsync(Paint paint)
        {
            Paint toUpdate = paintList.First(t => t.PaintId == paint.PaintId);
            toUpdate.Weight = paint.Weight;
            toUpdate.Amount= paint.Amount;
            WritePaintFile();
        }

        public async Task<Paint> getAsync(int Id)
        {
            return paintList.FirstOrDefault(t => t.PaintId == Id);
        }

        

        public async Task RemovePaintAsync(int Id)
        {
            Paint toRemove = paintList.First(t => t.PaintId == Id);
            paintList.Remove(toRemove);
            WritePaintFile();
        }


        private void WritePaintFile()
        {
            string paintAsJson = JsonSerializer.Serialize(paintList);
            File.WriteAllText(paintFile, paintAsJson);
        }
    }
}

