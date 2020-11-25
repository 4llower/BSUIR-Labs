.model small
.stack 100h
.data
    count dw 26 dup(0)
.code
main:
    mov ax, @data ; initialize data segment
    mov ds, ax

    read_cycle:
        mov ah, 01h
        int 21h
        
        cmp al, 10
        je break_read_cycle
        cmp al, 13
        je break_read_cycle   
        
        cbw
        mov si, ax
        sub si, 'a'
        inc [count[si]]
    jmp read_cycle

    break_read_cycle:
        mov cx, 26
        count_cycle:
            cmp cx, 0
            je return

            mov ax, 26
            sub ax, cx  

            mov si, ax
            mov bl, byte ptr count[si]

            output_cycle:
                cmp bl, 0
                je break
                mov dx, si
                add dx, 'a'
                mov ah, 02h
                int 21h
                
                dec bl
            jmp output_cycle

            break:
                dec cx
        jmp count_cycle
    return: 
        mov ah, 4ch ; exit interrupt
        int 21h
end main