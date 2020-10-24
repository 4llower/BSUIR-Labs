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

read_number proc C near
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

        cmp al, 13; enter key clicked check
        je return_read_number
        
        ; compare on correct symbol entering
        cmp al, '0'
        jb read_cycle
        cmp al, '9'
        ja read_cycle

        ; ** Magic **

        cmp al, '0' ; case then we have a prefix of '0'
        ja logic

        cmp cx, 0
        je logic

        cmp bx, 0
        jnz logic

        jmp read_cycle

        logic:
            mov last_symbol, al; save last symbol because working with ax(al changes)
            
            mov ax, bx; overflow check

            mov dx, 10
            mul dx
            jc read_cycle ; 1st check

            mov dx, 0
            mov dl, last_symbol
            sub dl, '0'

            add ax, dx

            jc read_cycle ; 2nd check

            mov bx, ax ; if we have no overflow add digit to number
            
            inc cx; add 1 to length of number
            jmp symbol_write ; writing symbol

        backspace_clicked:
            cmp cx, 0 ; check on empty string
            je read_cycle

            mov dx, 0
            mov ax, bx  
            mov bx, 10
            div bx
            mov bx, ax

            call remove_symbol ; remove last symbol

            dec cx ; decrease length of number

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

    return_read_number:
        
        mov dl, 0Ah;'\n' start
        mov ah, 02h
        int 21h

        mov dl, 0Dh
        mov ah, 02h
        int 21h; '\n' end

        mov ax, bx; move result to ax
        ret
read_number endp

print_number proc C near 
arg number: word
uses ax, bx, cx, dx
    mov ax, number
    mov cx, 0

    fill_stack:
        mov dx, 0 ; divide on ten
        mov bx, 10
        div bx 
        
        push dx; save digit in stack
        inc cx        

        cmp ax, 0 ; check if ax equal zero
        je write_cycle
    jmp fill_stack

    write_cycle:
        cmp cx, 0
        je return_print_number

        pop dx
        add dx, '0'
        mov ah, 02h
        int 21h

        dec cx
    jmp write_cycle

    return_print_number:
        ret
print_number endp
main:
    mov ax, @data ; initialize data segment
    mov ds, ax 

    call read_number

    call print_number C, ax

    return: 
        mov ah, 4ch ; exit interrupt
        int 21h
end main