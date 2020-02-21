#! /bin/bash

CompanyName=GravitonStudios

rm -rf nuspec
mkdir nuspec

function generate() {
DIRNAME=${CompanyName}.$1.iOS
FILENAME=${DIRNAME}.nuspec

cd ${DIRNAME}
if test -f "${FILENAME}"; then
    rm ${FILENAME}
fi
nuget spec
mv ${FILENAME} ../nuspec/
cd ..    
}

projects=(
    BraintreeApplePay
    BraintreeCard
    BraintreeCore
    BraintreePaymentFlow
    BraintreePayPal
    BraintreeUnionPay
    PayPalDataCollector
    PayPalOneTouch
    PayPalUtils
    CardinalMobile
)
for project_name in "${projects[@]}"
do
generate $project_name
done
