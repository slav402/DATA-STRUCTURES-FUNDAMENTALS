namespace CouponOps.Models
{
    public class Coupon
    {
        public Coupon(string code, int discountPercentage, int validity)
        {
            this.Code = code;
            this.DiscountPercentage = discountPercentage;
            this.Validity = validity;
        }

        public Coupon(Website website)
        {
            this.Website = website;
        }

        public string Code { get; set; }
        public int DiscountPercentage { get; set; }
        public int Validity { get; set; }
        public Website Website { get; set; }
    }
}
