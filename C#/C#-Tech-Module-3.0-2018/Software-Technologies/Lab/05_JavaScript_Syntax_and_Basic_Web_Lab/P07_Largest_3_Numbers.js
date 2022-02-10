function solve([arr]){
    let nums = [...arr.split(' ').map(n=>Number(n))];
    nums = nums.sort((a,b) => a-b)
    
    console.log(nums);
    
    if(nums.length < 3){
        for(let i = nums.length - 1;i >= 0; i--){
            console.log(`${nums[i]}`);
        }
    }
    else{
        let count = 0;
        while(count !== 3){
            console.log(nums[nums.length-count-1]);
            count++;
        }
    }
}   

solve(['10 30 15 20 50 5']);
solve(['20 30']);
solve(['10 5 20 3 20']);