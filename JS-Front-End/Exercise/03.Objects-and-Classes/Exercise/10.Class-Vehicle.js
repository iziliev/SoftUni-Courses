function part(){
    class Vehicle{
        constructor(type,model,parts,fuel){
            this.type=type
            this.model = model
            this.parts=parts
            this.parts.quality = this.parts.power*this.parts.engine
            this.fuel=fuel
        }

        drive(km){
            this.fuel-=km
        }
    }
    let parts = { engine: 6, power: 100 };
    let vehicle = new Vehicle('a', 'b', parts, 200);
    vehicle.drive(100);
    console.log(vehicle.fuel);
    console.log(vehicle.parts.quality);
}

part()


