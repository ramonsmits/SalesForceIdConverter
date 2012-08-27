# Summary

Simple utility class for .net that can convert SalesForce id's to and from decimal type.
It is written to just make conversion possible and currently not to be the fastest
conversion possible.


# Usage

From SalesForce string id to decimal:

    string salesForceStringId = "00330000000xEft";
    decimal id = SalesForceIdConverter.From(salesForceStringId);

From decimal to SalesForce string;

    decimal id = 1234567890;
    bool appendChecksum = true;
    string salesForceStringId = SalesForceIdConverter.From(id, appendChecksum);


# License

This code is provided as creative commons attribution license 3.0 (CC BY 3.0)
http://creativecommons.org/licenses/by/3.0/
