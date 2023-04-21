using Microsoft.AspNetCore.Mvc.Rendering;

namespace BykeSellingOnlinePlatefrom.Models.ViewModel
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Make> Makes { get; set; }


        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Make> items)
        {
            List<SelectListItem> makelist = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---select--",
                Value = "0"
            };

            makelist.Add(sli);

            foreach (Make make in items)
            {
                sli = new SelectListItem
                {
                    Text = make.Name,
                    Value = make.Id.ToString()
                };
                makelist.Add(sli);
            }

            return makelist;

        }
    }
}
