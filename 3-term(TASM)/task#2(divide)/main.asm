.model small
.stack 100h
.data
 last_symbol db ?
 ten dw 10
.code

remove_symbol proc C near
    mov ah, 02h
    mov dl, 8
    int 21h
    mov dl, 32
    int 21h
    mov dl, 8
    int 21h
    ret
remove_symbol endp

get_number proc C near
uses bx, cx, dx
    mov bx, 0
    mov cx, 0

    read_cycle:
        mov ax, 0

        mov ah, 08h; read char symbol
        int 21h

        cmp al, 8; backspace key clicked check
        je backspace_clicked

        cmp al, 27; esc key clicked check
        je esc_clicked
        
        ; compare on correct symbol entering
        cmp al, '0'
        jb read_cycle
        cmp al, '9'
        ja read_cycle

        ; ** Magic **

        mov last_symbol, al; save last symbol because working with ax(al changes)
        
        mov ax, bx; overflow check

        mul ten
        jc read_cycle ; 1st check

        mov dx, 0
        mov dl, last_symbol
        sub dl, '0'
        cmp dl, 2
        add ax, dx
        jc read_cycle ; 2nd check

        mov bx, ax ; if we have no overflow add digit to number
        
        add cx, 1 ; add 1 to length of number
        jmp symbol_write ; writing symbol

        backspace_clicked:
            cmp cx, 0 ; check on empty string
            je read_cycle

             ; remove last symbol 


            call remove_symbol
              mov ax, bx
              div ten
              mov bx, ax
            ;   div ten
            ;   mov bx, ah

            add cx, -1 ; decrease length of number

        jmp read_cycle ; start new iteration

        esc_clicked:
            cmp cx, 0 ; check on empty string
            je read_cycle

            delete_cycle:
                call remove_symbol
            loop delete_cycle
            mov bx, 0
        jmp read_cycle; start new iteration

        symbol_write:
            mov dl, last_symbol
            mov ah, 02h
            int 21h

        jmp read_cycle

    ret
get_number endp

main:
    mov ax, @data ; initialize data segment
    mov ds, ax 

    call get_number

    return: 
        mov ah, 4ch ; exit interrupt
        int 21h
end main