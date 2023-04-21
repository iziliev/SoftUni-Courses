function songs(data){
    let n = data[0]
    let typeList = data[data.length-1]

    class Song {
        constructor(type,name,time){
            this.type=type
            this.name=name
            this.time=time
        }
    }

    let songs=[]

    for (let i = 1; i <= n; i++) {
        let [type,name,time] = data[i].split('_')
        let song = new Song(type,name,time)
        songs.push(song)
    }

    if(typeList === 'all'){
        songs.forEach(x=>console.log(x.name))
    } else {
        let filterSong = songs.filter(x=>x.type===typeList)
        filterSong.forEach(x=>console.log(x.name))
    }
}

songs([3,
    'favourite_DownTown_3:14',
    'favourite_Kiss_4:16',
    'favourite_Smooth Criminal_4:01',
    'favourite']
    )