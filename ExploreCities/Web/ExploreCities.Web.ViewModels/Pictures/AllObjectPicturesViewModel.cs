namespace ExploreCities.Web.ViewModels.Pictures
{
    using System.Collections.Generic;

    public class AllObjectPicturesViewModel
    {
        public string ObjectId { get; set; }

        public int CarouselIndex { get; set; }

        public IEnumerable<ObjectPictureViewModel> Pictures { get; set; }
    }
}
