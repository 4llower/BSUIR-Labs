.model small
.stack 100h
.data
.code

remove_symbol proc
    mov ah, 02h
    mov dl, 8
    int 21h
    mov dl, 32
    int 21h
    mov dl, 8
    int 21h
    ret
remove_symbol endp

is_overflow proc C near
arg cur: word, need_to_add: word
uses ax, dx
    mov ax, word
    mov dx, 10
    mul dx
    add ax, need_to_add
    ret
is_overflow endp

get_number proc C near
uses bx, cx, dx
    mov bx, 0
    mov cx, 0

    read_cycle:
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
        
        ; overflow check
        sub al, '0'
        mov dx, 0
        mov dl, al
        add al, '0'

        call is_overflow C, bx, dx
        jc read_cycle

        ; add digit to number and calc
        mov ax, bx
        mov bx, 10
        mul bx
        add ax, dx
        mov bx, ax
        
        ; writing symbol
        add cx, 1
        jmp symbol_write

        backspace_clicked:
            call remove_symbol

            cmp cx, 0
            je read_cycle

            add cx, -1
        jmp read_cycle ; start new iteration

        esc_clicked:
            delete_cycle:
                call remove_symbol
            loop delete_cycle
        jmp read_cycle; start new iteration

        symbol_write:
            mov dl, al
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