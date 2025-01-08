[33mcommit 6a770d80667182452e7d7ad90282a4ced1f69b0e[m[33m ([m[1;36mHEAD[m[33m -> [m[1;32mAddingEnemies[m[33m, [m[1;31morigin/AddingEnemies[m[33m)[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Fri Jan 3 02:03:03 2025 +0530

    Adding Enemy Logic
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit 0410afda0ff48caafc1cda02f12dea168f101d27[m[33m ([m[1;31morigin/main[m[33m, [m[1;32mmain[m[33m)[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Thu Jan 2 00:17:39 2025 +0530

    Adding grass animations
    
    This CL adds animations for grass2,3,4 and 5. Grass 1 looked laggy and
    needs to be looked upon.
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit 8b4cf6ea33b30f9b642c09efa73e2f278ab0eafe[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Tue Dec 31 16:57:28 2024 +0530

    Building the level further
    
    This CL builds the level further.
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit 5a7b671a558c79d7cf6b1f201954e8d276334cbe[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Tue Dec 31 15:37:22 2024 +0530

    Pole breaking effect added
    
    This CL adds basic breaking effect of pole which needs to be refined
    further.
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit efcfda620c39ed50f1b4f05682715c06a53c4aa3[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Tue Dec 31 10:27:52 2024 +0530

    Added UpAttack Slash
    
    This CL adds the UpAttack slash. UpAttack animations are still a little
    laggy which will be fixed in the later commits.
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit c5a3c7a89c107028c27edf6eb5011b125327f1c0[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Tue Dec 31 02:29:58 2024 +0530

    Fixed UpAttack bug
    
    This CL fixes the bug in the up attack logic. Now if the player
    attack in quick succession, the direction is based on the user input at
    that instant itself. The FIX was to modify gravity value of Vertical in Unity Input
    Manager.
    
    Signed-off-by: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>

[33mcommit 72f1aa439cf6847cb29f097cf30e23e8a8f77355[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Tue Dec 31 01:18:28 2024 +0530

    Added UpAttack Animation
    
    This CL adds the very basic up attack animation which needs to be
    refined further.

[33mcommit c6917c46cd5fb8ea4ff656f7342d2ff84b5524c9[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Mon Dec 30 19:22:14 2024 +0530

    Adding attack slash
    
    This CL adds side and up attack slashes, up slash still to be
    animated and down slash will be implemented next.

[33mcommit fa8ce911ede266f6be22dcbc0bc2ddf22ff425af[m
Author: Abhishek Aggarwal <abhishekaggarwal896@gmail.com>
Date:   Mon Dec 30 10:04:52 2024 +0530

    Initial Commit
    
    This CL adds basic level design, foundation for attack button, and
    double jump.
