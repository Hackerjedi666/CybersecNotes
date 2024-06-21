echo "Enter the domain you wanna do zone transfer for :"; 
read domain;
for dnserver in $(host -t ns $domain | cut -d " " -f 4); do host -l megacorpone.com $dnserver; done | grep -v "not found" | grep -v "Transfer failed"


