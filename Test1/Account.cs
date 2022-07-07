using System;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    public class Account
    {
        [IcefProperty("Id")]
        public string AccountID { get; set; }

        [IcefProperty("Name")]
        public string AccountName { get; set; }

        [IcefProperty("Events_attended__c")]
        public string EventsattendednonICEF { get; set; }

        [IcefProperty("Mailing_State_Province__c")]
        public string MailingStateProvince { get; set; }

        [IcefProperty("MailingCountry__c")]
        public string MailingCountry { get; set; }

        [IcefProperty("Visited_Events__c")]
        public string ICEFEventsattendedlast100 { get; set; }

        [IcefProperty("Number_of_ICEF_events_visited__c")]
        public double? NumberofICEFevents { get; set; }

        [IcefProperty("French_Speaking_Account__c")]
        public bool? FrenchSpeakingAccount { get; set; }

        [IcefProperty("Most_Recent_ICEF_Event__c")]
        public DateTime? MostRecentICEFEvent { get; set; }

        [IcefProperty("Educational_Sector__c")]
        public string EducationalSector { get; set; }

        [IcefProperty("Mailing_Country_Region__c")]
        public string MailingCountryRegion { get; set; }

        [IcefProperty("ICEF_events_with_any_status__c")]
        public string ICEFeventswithanystatus { get; set; }

        [IcefProperty("Events_of_Interest__c")]
        public string EventsofInterest { get; set; }

        [IcefProperty("Free_text_for_filtering__c")]
        public string Freetextforfiltering { get; set; }

        [IcefProperty("Account_Owner_Name__c")]
        public string AccountOwnerName { get; set; }

        [IcefProperty("X20_year_mag_Take_From_List__c")]
        public bool? InsightsmagTakeFromList { get; set; }

        [IcefProperty("Insights_Ads_booked_2016__c")]
        public double? InsightsAdsbooked2020 { get; set; }

        [IcefProperty("Insights_Mag_adertiser_year__c")]
        public double? InsightsMagadvertiseryear { get; set; }

        [IcefProperty("French_Agency_Potential__c")]
        public bool? FrenchAgencyPotential { get; set; }

        [IcefProperty("Cultural_Exchange_Work_Travel__c")]
        public string CulturalExchangeWorkTravel { get; set; }

        [IcefProperty("Agency_Education_Sectors__c")]
        public string AgencyEducationSectors { get; set; }

    }
}
