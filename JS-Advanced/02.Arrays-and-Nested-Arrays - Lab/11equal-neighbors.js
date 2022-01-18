function solve(nums) {
    
    let pairs = 0;

    for (let i = 0; i < nums.length; i++) {
        
        for (let j = 0; j < nums[i].length; j++) {
            
            if (i === nums.length - 1) {
                if (nums[i][j] === nums[i][j + 1]) {
                    pairs++;
                }
            }
            else {
                if (nums[i][j] === nums[i + 1][j]) {
                    pairs++;
                }

                if (nums[i][j] === nums[i][j + 1]) {
                    pairs++;
                }
            }
        }
    }
    
    return pairs;
}