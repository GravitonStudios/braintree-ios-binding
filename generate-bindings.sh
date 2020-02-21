#! /bin/bash

function generate() {
    sharpie bind -sdk iphoneos -f ./frameworks/$1 -output ./bindings/$1 -namespace $1
}

frameworks=(
    Braintree3DSecure
    BraintreeAmericanExpress
    BraintreeApplePay
    BraintreeCard
    BraintreeCore
    BraintreeDataCollector
    BraintreePaymentFlow
    BraintreePayPal
    BraintreeVenmo
    BraintreeUI
    BraintreeUnionPay
    PayPalDataCollector
    PayPalOneTouch
    PayPalUtils
)
for framework in "${frameworks[@]}"
do
echo Biding $framework
generate $framework
done
