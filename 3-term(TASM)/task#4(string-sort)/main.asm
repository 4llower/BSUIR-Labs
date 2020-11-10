.model small
.stack 100h
.data
    
.code

write_carryover proc C near
uses ax, dx
    mov dl, 0Ah;'\n' start
    mov ah, 02h
    int 21h

    mov dl, 0Dh
    mov ah, 02h
    int 21h; '\n' end
    ret
write_carryover endp

main:
    mov ax, @data ; initialize data segment
    mov ds, ax

    

    return: 
        mov ah, 4ch ; exit interrupt
        int 21h
end main