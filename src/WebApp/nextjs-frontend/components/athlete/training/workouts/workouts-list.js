import style from "./workouts-list.module.css";
import React from "react";

import DeleteModal from "../../../reusable/delete-modal";
import WorkoutModal from "../../modals/workout-modal";
import { Stack } from "@mui/system";
import { Pagination } from "@mui/material";

const WorkoutsList = ({ workouts }) => {
  return (
    <div className={style.container}>
      <div className={style.header}>
        <h2>Workouts</h2>
        <p>Manage workouts here.</p>
      </div>
      <div className='relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-md rounded-xl'>
        <div className='rounded-t py-3 border-0'>
          <div className='flex flex-wrap items-center'>
            <div className='relative w-full px-4 max-w-full flex-grow flex-1'>
              <h3 className='font-semibold text-base text-blueGray-700 my-auto'>
                Latest workouts
              </h3>
            </div>
            <div className='relative w-full px-4 max-w-full flex-grow flex-1 text-right'>
              <WorkoutModal
                icon='/thumbnails/add-outline.svg'
                text='Add new'
                backgroundColorValue='#8098F9'
                isHoveringColor='#C7D7FE'
                extraStyleType='color'
                extraStyleValue='white'
                isDetails={false}
              />
            </div>
          </div>
        </div>
        <div className='block w-full overflow-x-auto'>
          <table className='items-center w-full bg-transparent border-collapse'>
            <thead className='thead-light bg-indigo-400 text-white'>
              <tr>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Name
                </th>
                <th className='px-6  align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Category
                </th>
                <th className='px-6 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left'>
                  Number of exercises
                </th>
                <th className='px-6 bg-blueGray-50 text-blueGray-500 align-middle border border-solid border-blueGray-100 py-3 text-xs uppercase border-l-0 border-r-0 whitespace-nowrap font-semibold text-left min-w-140-px'></th>
              </tr>
            </thead>
            <tbody className='divide-y divide-gray-200'>
              {workouts.map((workout) => {
                return (
                  <tr key={workout.id}>
                    <td className='text-xs p-4'>{workout.name}</td>
                    <td className='text-xs p-4'>{workout.category}</td>
                    <td className='text-xs p-4'>
                      {workout.exerciseDtos.length}
                    </td>

                    <td className='border-t-0 px-6 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap p-4 grid justify-items-end'>
                      <Stack
                        direction='row'
                        spacing={2}
                        className='items-center'
                      >
                        {/* <WorkoutModal
                          icon='/thumbnails/copy-outline.svg'
                          isDetails={true}
                          exercise={exercise}
                          backgroundColorValue='white'
                          isHoveringColor='#D0D5DD'
                          borderValue='none'
                        />
                        <WorkoutModal
                          icon='/thumbnails/modify.svg'
                          isDetails={false}
                          exercise={exercise}
                          backgroundColorValue='white'
                          isHoveringColor='#D0D5DD'
                          borderValue='none'
                        /> */}
                        <DeleteModal
                          subtitle={`Remove workout "${workout.name}"`}
                          endpoint={`workouts/${workout.id}`}
                          redirect='/athlete/exercise'
                        />
                      </Stack>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          <div className='flex flex-row items-center justify-center p-6 w-full'>
            <Pagination></Pagination>
          </div>
        </div>
      </div>
    </div>
  );
};

export default WorkoutsList;
