function cityInfo(parameter){
    let city = {
        name:parameter.name,
        area:parameter.area,
        population:parameter.population,
        country:parameter.country,
        postCode:parameter.postCode
    }

    for (const key in city) {
        console.log(`${key} -> ${parameter[key]}`)
    }
}

cityInfo({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"})