# HtmlDiff
HtmlDiff compare


            var oldValue =
                "A  ensure that <strong>commercial </strong>air transport from <u>its</u> State <s>have </s>established, xxxxxxxxxxxxxxx yyyyyyyyyyyyyyyyyy zzzzzz,implemented and maintained a  .<br /><sup>2</sup>YYYYXX<sub>2</sub><br /><br />m1=m2=m3=?1*A1*V1=?2*A2*V2=?3*A3*V3=constant<br /><br />L=*v(T*(K))";

            var newValue =
                "A  ensure that <strong>commercial </strong>air transport , xxxxxxxxxxxxxxx yyyyyyyyyyyyyyyyyy zzzzzz,implemented and maintained a  .<br /><sup>2</sup>YYYYXX<sup>2</sup><br /><br />m1=m2=m3=?1*A1*V1=?2*A2*V2=?3*A3*V3=constant<br /><br />L=*v(T*(K)) ali ata bak lütfen";

            var newText = new CompareLibrary().CompareText(oldValue, newValue);
