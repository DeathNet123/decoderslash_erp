namespace decoderslash_erp.Models
{
    public class CardModelLeft
    {
        public int Counter { get; set; } //Numeric Value
        public String? Tag { get; set; } //Main Tag

        public String? Tag2 { get; set; } //sub tag...
        public String? Icon { get; set; } //Icon data of fontawesome..
        public String? Types { get; set; } //Left, Right, Progress, Large..

        public String? Controller { get; set; } //asp-controller

        public String? Action { get; set; } //asp-action...

        public String? Volume { get; set; } //This one is only for the Progress card... 
    }
}