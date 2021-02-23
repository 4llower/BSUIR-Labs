FROM python:3.8-slim-buster

WORKDIR /docker-test

ENV VIRTUAL_ENV=/opt/venv
RUN python3 -m venv $VIRTUAL_ENV
ENV PATH="$VIRTUAL_ENV/bin:$PATH"

COPY requirements.txt .
RUN pip install -r requirements.txt

COPY main.py .
CMD ["python", "main.py"]