using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MediaWcfService
{
    public class MyTable
    {
        public int Id { get; set; }
        public string Vocalist { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Length { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MediaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MediaService.svc or MediaService.svc.cs at the Solution Explorer and start debugging.
    public class MediaService : IMediaService
    {
        public List<MyTable> GetTable()
        {
            MediaDataClassesDataContext db = new MediaDataClassesDataContext();
            Table<MediaTable> table = db.GetTable<MediaTable>();
            List<MyTable> result = new List<MyTable>(20);
            foreach (var item in table)
            {
                result.Add(new MyTable()
                {
                    Id = item.Id,
                    Vocalist = item.Vocalist,
                    Album = item.Album,
                    Name = item.Name,
                    Path = item.Path,
                    Length = item.Length
                });
            }

            return result;
        }
    }
}
