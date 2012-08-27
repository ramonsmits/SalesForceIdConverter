# Summary

Simple utility class for .net that can convert [SalesForce][sf] id's to and from decimal type. SalesForce id's
are 15 or 18 character strings which are
* Base62 encoded (15 characters)
* Have an optional checksum (3 characters)
* Case sensitive but with the checksum be processed case-insensitive

It is written to just make conversion possible and currently not to be the fastest conversion possible.

The BaseConverter used in the code is based on code I found on [stackoverflow][so] but refactored for the decimal type.


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


[sf]: http://www.salesforce.com
[so]: http://stackoverflow.com