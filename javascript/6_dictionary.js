const products01 = {
    "product": [
        "dress",
        "xxxTT^&LL",
        " "
    ],
    "returned_info": [
        "Sort by",
        "No results",
        "No results"
    ]
}

for (var key in products01) {
    value = products01[key]
    for (i in value) {
        // console.log(value[i])
    }
}

product = products01['product']
return_info = products01['returned_info']

for (let i = 0; i < product.length; i++) {
    p = product[i]
    r = return_info[i]
    console.log(p, ': ', r)
}