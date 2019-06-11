namespace JDC.Api.Versioning.Samples.CustomBuilder.Config.V12.Models {

    public class BModel {

        public int ID { get; set; }
        public string Value { get; set; } = "B Value";
        public string NewProperty { get; set; } = "Only in V12";
    }
}
