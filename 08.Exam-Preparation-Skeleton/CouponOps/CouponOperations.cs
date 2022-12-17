namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> couponsByCode = new Dictionary<string, Coupon>();
        private Dictionary<string, Website> websitesByDomain = new Dictionary<string, Website>();

        public void AddCoupon(Website website, Coupon coupon)
        {
            this.couponsByCode.Add(coupon.Code, coupon);

            if (!websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this.websitesByDomain[website.Domain].Coupons.Add(coupon);
            coupon.Website = website;
        }

        public bool Exist(Website website)
        {
            return this.websitesByDomain.ContainsKey(website.Domain);
        }

        public bool Exist(Coupon coupon)
        {
            return this.couponsByCode.ContainsKey(coupon.Code);
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }
            
            return this.couponsByCode.Values.Where(x => x.Website == website);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return this.couponsByCode.Values.OrderByDescending(x => x.Validity).ThenByDescending(x => x.DiscountPercentage);
        }

        public IEnumerable<Website> GetSites()
        {
            return this.websitesByDomain.Values;
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return this.GetSites().OrderBy(x => x.UsersCount).ThenByDescending(x => x.Coupons.Count);
        }

        public void RegisterSite(Website website)
        {
            if (websitesByDomain.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            websitesByDomain.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!this.couponsByCode.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            var removedCoupon = couponsByCode[code];
            couponsByCode.Remove(code);

            return removedCoupon;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this.websitesByDomain.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            var removedWebsite = this.websitesByDomain[domain];
            var couponsForDel = this.websitesByDomain[domain].Coupons;

            foreach (var coupon in couponsForDel)
            {
                couponsByCode.Remove(coupon.Code);
            }

            websitesByDomain.Remove(domain);

            return removedWebsite;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!websitesByDomain.ContainsKey(website.Domain) || !couponsByCode.ContainsKey(coupon.Code))
            {
                throw new ArgumentException();
            }

            if (!website.Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            
            website.Coupons.Remove(coupon);
            couponsByCode.Remove(coupon.Code);
        }
    }
}
