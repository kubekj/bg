import React from "react";
import Link from "next/link";
import Router from "next/router";

import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import {Button} from "@mui/material";
import CustomButton from "../reusable/button";
import {useSession} from "next-auth/react";
import {deleter} from "../../lib/rest-api";
import {handleSuccess} from "../../lib/success-handler";

function DeleteModal({endpoint, redirect, subtitle}) {
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);
    const {data} = useSession();

    async function removeGivenObject() {
        await deleter(endpoint, data.jwt);
        handleClose();
        Router.replace(redirect);
    }

    return (
        <>
            <CustomButton
                iconSrc='/thumbnails/trash-bin-outline.svg'
                backgroundColorValue='white'
                isHoveringColor='#D0D5DD'
                borderValue='none'
                onClick={handleOpen}
            />
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby='modal-modal-title'
                aria-describedby='modal-modal-description'
            >
                <div className='relative top-1/4 mx-auto flex flex-col items-center bg-white w-1/3 rounded-xl'>
                    <div className='flex flex-col isolate w-full bg-gray-200 p-10 rounded-t-xl'>
                        <div className='flex flex-row place-content-between w-full'>
                            <Typography id='modal-modal-title' variant='h6' component='h2'>
                                Delete
                            </Typography>
                            <Link href={""} className='no-underline text-gray-800'>
                                <Typography
                                    id='modal-modal-title'
                                    variant='h6'
                                    component='h2'
                                    onClick={handleClose}
                                >
                                    x
                                </Typography>
                            </Link>
                        </div>
                        <Typography
                            id='modal-modal-subtitle'
                            className='text-gray-600'
                            sx={{mt: 1}}
                        >
                            {subtitle}
                        </Typography>
                    </div>
                    <div className='flex flex-col items-start p-10 gap-5 w-full'>
                        <div className='flex flex-col justify-center gap-3 w-full'>
                            <Typography
                                id='modal-modal-description'
                                className='text-gray-800'
                                sx={{mt: 1}}
                            >
                                If you delete that record, it will disapear permanently. Are you
                                sure you want to do that ?
                            </Typography>
                        </div>
                    </div>
                    <div className='flex flex-col px-8 py-2 w-full items-center'>
                        <div className='flex flex-row w-full gap-3 py-6'>
                            <Button
                                style={{
                                    backgroundColor: "#D0D5DD",
                                    color: "#000000",
                                    borderRadius: 14,
                                    border: "none",
                                }}
                                variant='outlined'
                                onClick={handleClose}
                                className='w-1/2'
                            >
                                Cancel
                            </Button>
                            <Button
                                style={{
                                    backgroundColor: "#B22222",
                                    borderRadius: 14,
                                }}
                                variant='contained'
                                type='submit'
                                className='w-1/2'
                                onClick={removeGivenObject}
                            >
                                Remove
                            </Button>
                        </div>
                    </div>
                </div>
            </Modal>
        </>
    );
}

export default DeleteModal;
