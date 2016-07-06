        public class orderItemShipping
        {
            public string itemNo { get; set; }
            public string sku { get; set; }
            public string description { get; set; }
            public string nativeDescription { get; set; }
            public string hsCode { get; set; }
            public string originCountry { get; set; }
            public int? unitValue { get; set; }
            public int? itemCount { get; set; }
            public int weight { get; set; }
            public string productURL { get; set; }
        }

        public class eTowerOrder
        {
            public string trackingNo { get; set; }
            public string referenceNo { get; set; }
            public string addressLine1 { get; set; }
            public string addressLine2 { get; set; }
            public string addressLine3 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string description { get; set; }
            public string email { get; set; }
            public string facility { get; set; }
            public string instruction { get; set; }
            public string invoiceCurrency { get; set; }
            public int? invoiceValue { get; set; }
            public string phone { get; set; }
            public string platform { get; set; }
            public string postcode { get; set; }
            public string recipientCompany { get; set; }
            public string recipientName { get; set; }
            public string serviceOption { get; set; }
            public string sku { get; set; }
            public string state { get; set; }
            public string weightUnit { get; set; }
            public double? weight { get; set; }
            public string dimensionUnit { get; set; }
            public int length { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public int volume { get; set; }
            public string shipperName { get; set; }
            public string shipperAddressLine1 { get; set; }
            public string shipperAddressLine2 { get; set; }
            public string shipperAddressLine3 { get; set; }
            public string shipperCity { get; set; }
            public string shipperState { get; set; }
            public string shipperPostcode { get; set; }
            public string shipperCountry { get; set; }
            public string shipperPhone { get; set; }
            public string recipientTaxId { get; set; }
            public string authorityToLeave { get; set; }
            public string incoterm { get; set; }
            public string lockerService { get; set; }
            public List<orderItemShipping> orderItems { get; set; } = new List<orderItemShipping>();
            public string firstPieceReferenceNo { get; set; }
            public string returnName { get; set; }
            public string returnAddressLine1 { get; set; }
            public string returnAddressLine2 { get; set; }
            public string returnAddressLine3 { get; set; }
            public string returnCity { get; set; }
            public string returnState { get; set; }
            public string returnPostcode { get; set; }
            public string returnCountry { get; set; }
            public string returnOption { get; set; }
  
        }

        public class eTowerOrderRespone
        {
            public string status { get; set; }
            public int code { get; set; }
            public string message { get; set; }
            public string orderId { get; set; }
            public string referenceNo { get; set; }
            public string trackingNo { get; set; }
        }
         
        public List<eTower.eTowerLabelRequest> GetEtowerLabelByExternalRef(long external_ref)
        {
            eTower.eTowerLabelRequest x = new eTower.eTowerLabelRequest();
            x.id = external_ref.ToString();
            return new List<eTower.eTowerLabelRequest>() { x };
        }
