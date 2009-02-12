using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignMonitorAPIWrapper
{
    public class ListSegment
    {
        public ListSegment(string listID, string segmentName)
        {
            ListID = listID;
            SegmentName = segmentName;
        }

        public string ListID { get; set; }
        public string SegmentName { get; set; }
    }
}
