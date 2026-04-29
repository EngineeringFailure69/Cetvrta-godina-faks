#define _CRT_SECURE_NO_WARNINGS
#define MSMPI_NO_DEPRECATE_20
#include<stdio.h>
#include<mpi.h>
#include<stdlib.h>

#define M 10
#define N M*(M+1)/2

void printFile(char filePath[], int size)
{
	FILE* f = fopen(filePath, "rb");
	int total = size * N;
	int* buf = (int*)malloc(total * sizeof(int));

	fread(buf, sizeof(int), total, f);
	fclose(f);

	for (int i = 0; i < total; i++)
		printf("%d ", buf[i]);
	printf("\n");

	free(buf);
}

int main(int argc, char* argv[])
{
	int size, rank;
	MPI_File file1, file2;
	MPI_Offset offset;
	char path1[] = "file1.dat";
	char path2[] = "file2.dat";
	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	int* inputBuf = (int*)malloc(N * sizeof(int));
	offset = (MPI_Offset)rank * N * sizeof(int);
	for (int i = 0; i < N; i++)
		inputBuf[i] = rank;
	
	//A)
	MPI_File_open(MPI_COMM_WORLD, path1, MPI_MODE_CREATE | MPI_MODE_WRONLY, MPI_INFO_NULL, &file1);
	MPI_File_seek(file1, offset, MPI_SEEK_SET);
	MPI_File_write(file1, inputBuf, N, MPI_INT, MPI_STATUS_IGNORE);
	MPI_File_close(&file1);
	free(inputBuf);
	MPI_Barrier(MPI_COMM_WORLD);
	//if (rank == 0)
		//printFile(path1, size);

	//B)
	int* outputBuf = (int*)malloc(N * sizeof(int));
	MPI_File_open(MPI_COMM_WORLD, path1, MPI_MODE_RDONLY, MPI_INFO_NULL, &file1);
	MPI_File_read_at(file1, offset, outputBuf, N, MPI_INT, MPI_STATUS_IGNORE);
	MPI_File_close(&file1);
	/*for (int i = 0; i < N; i++)
		printf("r%d-%d ", rank, outputBuf[i]);
	free(outputBuf);*/
	MPI_Barrier(MPI_COMM_WORLD);

	//C)
	int blocks = 1;
	if (rank == 0) 
	{
		int blockData = 1;
		while (blockData != N) 
		{
			blocks++;
			blockData += blocks;
		}
	}

	MPI_Bcast(&blocks, 1, MPI_INT, 0, MPI_COMM_WORLD);
	int* blockLengths = (int*)malloc(blocks * sizeof(int));
	int* blockDisplacements = (int*)malloc(blocks * sizeof(int));
	int displacement = 0;
	for (int i = 0; i < blocks; i++) 
	{
		blockLengths[i] = i + 1;
		blockDisplacements[i] = displacement;
		displacement += blockLengths[i] * size + rank;
	}
	MPI_Datatype indexed;
	MPI_Type_indexed(blocks, blockLengths, blockDisplacements, MPI_INT, &indexed);
	MPI_Type_commit(&indexed);
	MPI_File_open(MPI_COMM_WORLD, path2, MPI_MODE_WRONLY | MPI_MODE_CREATE, MPI_INFO_NULL, &file2);
	MPI_File_set_view(file2, rank * sizeof(int), MPI_INT, indexed, "native", MPI_INFO_NULL);
	MPI_File_write_all(file2, outputBuf, N, MPI_INT, MPI_STATUS_IGNORE);
	MPI_File_close(&file2);
	free(outputBuf);
	free(blockLengths);
	free(blockDisplacements);
	if (rank == 0)
		printFile(path2, size);

	MPI_Finalize();
	return 0;
}